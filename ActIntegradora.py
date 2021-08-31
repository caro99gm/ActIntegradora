#Tamaño n x m es random? yo decido
#Como se ponen las cajas, o se ponen en random? Como se ponen en el grid? es otro agente
#Las cajas son agentes? si
#Como se mueven las cajas dentro del codigo? aqui no se muestra eso
#Se pueden agarrar cajas en diagonales? si
#Las cajas siempre seran divisibles entre 5? no
#Como se sabe que ya termino?Termina por tiempo? si, pero hay otra solucion

#Que son los estantes que se mencionan?
#Por que se necesita una puerta en el escenario? puro diseño
#Los estantes se ponen en cualquier lugar?
#Las cajas se ponen en un estante?

#consola, ya acabamos, nos tardamos tanto tiempo, tantos pasos, etc...

import agentpy as ap
import numpy as np
import random

import matplotlib.pyplot as plt
import seaborn as sns
import IPython


class agentePila(ap.Agent):
    def setup(self):
        self.grid = self.model.grid
        self.random = self.model.random
        self.group = self.random.choice(range(self.p.n_groups))
        self.cajas = 0
        self.lleno = False
        
    def setup_parameters(self):
        pass
    
    def aumentarPila(self):
        self.cajas += 1
    
    def checkPila(Self):
        if(self.cajas == 5):
            lleno = True
        else:
            lleno = False
    
class agenteCaja(ap.Agent):
    def setup(self):
        self.grid = self.model.grid
        self.random = self.model.random
        self.group = self.random.choice(range(self.p.n_groups))
        self.picked = False
       
        
    def setup_parameters(self):
        pass
    
    def pickup(self):
        self.picked = True
        
    def removeCaja(self):
        remove_agents(self)

class agenteRobot(ap.Agent):
    def setup(self):
        self.grid = self.model.grid
        self.random = self.model.random
        self.group = self.random.choice(range(self.p.n_groups))
        self.move = {"l": (-1,0) ,"r": (1,0),"u": (0,-1),"d": (0,1)}
        self.stuck = False
    
    def setup_parameters(self, velocidad, cajaCarga, posX, posZ,n,m):
        self.velocidad = velocidad #bool, solo on y off
        self.cajaCarga = None #bool, la tiene o no
        self.direccion = True
        self.n = n#si x < n
        self.m = m#si z < m
        self.posX = self.grid.positions[self][0] #int, se movera en cuadrantes
        self.posZ = self.grid.positions[self][1] #int, se movera en cuadrantes
        self.posY = 0 #0, no se mueve hacia arriba
        
    #cambiarla (prendido -> apagado)
    def actualizarVelocidad(self, velocidad):
        check = velocidad
        if(check):
            velocidad = False
        else:
            velocidad = True
    
    def actualizarPosicion(self, posX, posZ):
        keys = []
        for k in self.move:
            keys.append(k)
        direction = self.random.choice(k)
        
        #self.move = {"l": (-1,0) ,"r": (1,0),"u": (0,-1),"d": (0,1)}
        self.posX = self.posX + self.move[direction][0]
        self.posZ = self.posZ + self.move[direction][1]
    
        #derecha
        self.grid.move_by(self, (self.move[direction][0],self.move[direction][1]))
        #izquiera
        #self.grid.move_by(self, (-1,0))
        #arriba
        #self.grid.move_by(self, (0,1))
        #abajo
        #self.grid.move_by(self, (0,-1))

    def depositaCaja(self, pila):
        pila.aumentarPila()
        self.cajaCarga.removeCaja()
        self.cajaCarga = None
        
        
    def detectarObstaculos(self):
        #Campo libre
        #if self.posX+1 == campo:
        #    actualizarPosicion(self.posX, self.posZ)
        self.move = {"l": (-1,0) ,"r": (1,0),"u": (0,-1),"d": (0,1)}
        if self.posX == self.n-1:
            self.move.pop('r')
        if self.posX == 0:
            self.move.pop('l')
        if self.posZ == self.m-1:
            self.move.pop('d')
        if self.posZ == 0:
            self.move.pop('u')
        neighbors = self.grid.neighbors(self)
        for n in neighbors:
            if self.cajaCarga and n == "agentePila" and n.cajas < 5:
                #deposita la caja
                for pos in self.move:
                    if self.grid.positions[n] == (posX + self.move[pos][0],posZ + self.positions[pos][1]): #arriba
                        self.move.pop(pos)
                        continue
        if len(self.move) == 0:
            stuck = True

            
        #Pared
        #Cajas
        #CantCajasPila
        #Robot
        
    def detectarCargaCaja(self):
        #if self.cajaCarga == true:
         #   print('tiene la caja')
        #else:
         #   print('no tiene la caja')
        neighbors = self.grid.neighbors(self)
        
        for n in neighbors:
            if(n.type == "agenteCaja" and not n.picked):
                print("PICKEO LA CAJAAAAAAAAAA")
                self.cajaCarga = n
                n.pickup()
                break
        #if(neighbors == self.agenteCaja):
        #     cajaCarga = True
        #else:
        #    cajaCarga = False
    
class modeloRobot(ap.Model):
    def setup(self):
        s = self.p.size
        n = 5
        n_caja = random.randrange(self.p.size - 1) + 1
        self.grid = ap.Grid(self, (s, s), track_empty=True)
        self.agents = ap.AgentList(self, n, agenteRobot)
        self.cajas = ap.AgentList(self,n_caja, agenteCaja)
        self.grid.add_agents(self.agents, random = True, empty = True)
        self.grid.add_agents(self.cajas, random = True, empty = True)
        
        self.agents.setup_parameters(self.p.velocidad, self.p.cajaCarga, self.p.posX, self.p.posZ,s,s)
    
    def step(self):
        for i in self.grid.positions:
            print (i, self.grid.positions[i])
            
        self.agents.detectarCargaCaja()
        self.agents.detectarObstaculos()
        self.agents.actualizarPosicion(self.p.posX, self.p.posZ)
        
        #if(stuck):
         #   self.agents.agenteRobot.position - 1 para abajo

    def update(self):
        self.agents.actualizarVelocidad(self.p.velocidad)
    
    def end(self):
        self.report('Distancia recorrida por los vehiculos en el eje x', self.agents.posX)
        self.report('Distancia recorrida por los vehiculos en el eje z', self.agents.posZ)

parameters = {
    'size': 10,
    'velocidad': 0,
    'cajaCarga': 0,
    'posX': 0,
    'posZ': 0,
    'steps': 100,
    'n_groups': 3
}

model = modeloRobot(parameters)

results = model.run()

print("Impresion de la info del tipo de dato result")
print(results)
print("Impresion de la info del reporte en result")
print(results.reporters)
print("Impresion de la información de la simulación")
print(results.info)
    