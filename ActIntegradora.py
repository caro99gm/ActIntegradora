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
        self.grid.remove_agents(self)

class agenteRobot(ap.Agent):
    def setup(self):
        self.grid = self.model.grid
        self.random = self.model.random
        self.group = self.random.choice(range(self.p.n_groups))
        self.move = {"l": (-1,0) ,"r": (1,0),"u": (0,-1),"d": (0,1)}
        self.stuck = False
        self.izquierda = False
        self.encontrePila = False
    
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
    
    def actualizarPosicion(self):
        
        if self.stuck: return
        
        
        if self.cajaCarga:
            print(self, "CARGO UNA CAJAAAAAAAAA :))))")
            if self.encontrePila:
                if 'r' in self.move:
                    print(self, "me voy pala derecha")
                    self._move(1,0)
                else:
                    self._randomMove()
                # ve hacia la derecha
            elif self.izquierda:
                if 'u' in self.move:
                    print(self, "me voy parriba ")
                    self._move(0,-1)
                else:
                    self._move(1,0)
                    self._move(0,-1)
                    self._move(0,-1)
                    self._move(-1,0)
                    self._randomMove()
            else:
                if 'l' in self.move:
                    print(self, "me voy pal izquierda")
                    self._move(-1,0)
                else:
                    self._randomMove()
            #else
                # ve hacia la izquierda
        else:
            self._randomMove()
        #izquiera
        #self.grid.move_by(self, (-1,0))
        #arriba
        #self.grid.move_by(self, (0,1))
        #abajo
        #self.grid.move_by(self, (0,-1))
            
    def _move(self,horizontal,vertical):
        self.grid.move_by(self, (horizontal,vertical))
        self.posX += horizontal
        self.posZ += vertical
            
    def _randomMove(self):
        if self.cajaCarga:
            print(self, "me blokiaron voy random :((((")
        
        keys = []
        for k in self.move:
            keys.append(k)
        #print(self,"possible moves: ", keys)
        
        number = random.randint(0,len(keys)-1)
        direction = keys[number]
        #print(self,"choice:", direction, number)
        #self.move = {"l": (-1,0) ,"r": (1,0),"u": (0,-1),"d": (0,1)}

        #derecha
        self._move(self.move[direction][0] , self.move[direction][1])

    def depositaCaja(self, pila):
        print('PUSE LA CAJAAAAAAAAAAAAA', self.cajaCarga)
        pila.aumentarPila()
        self.cajaCarga.removeCaja()
        self.cajaCarga = None
        
        
    def detectarObstaculos(self):
        #Campo libre
        #if self.posX+1 == campo:
        #    actualizarPosicion(self.posX, self.posZ)
        self.izquierda = False
        self.encontrePila = False
        self.move = {"l": (-1,0) ,"r": (1,0),"u": (0,-1),"d": (0,1)}
        if self.posX == self.n-1:
            self.move.pop('r')
        if self.posX == 0:
            self.move.pop('l')
            self.izquierda = True
        if self.posZ == self.m-1:
            self.move.pop('d')
        if self.posZ == 0:
            self.move.pop('u')
        neighbors = self.grid.neighbors(self)
        for n in neighbors:
            if self.cajaCarga and n.type == "agentePila":
                if n.cajas < 5:
                    self.depositaCaja(n)
                else:
                    self.encontrePila = True
            deletePos = []
            for pos in self.move:
                if self.grid.positions[n] == (self.posX + self.move[pos][0],self.posZ + self.move[pos][1]):
                    deletePos.append(pos)
            for p in deletePos:
                self.move.pop(p)
        if len(self.move) == 0:
            stuck = True
            print('AIUDAAAAAAAAAAAAAAAAAAA')
        else:
            stuck = False
            
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
                print("PICKEO LA CAJAAAAAAAAAAAAAAA", n)
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
        self.n_caja = random.randrange(self.p.size - 1) + 1
        pilas = self.n_caja // 5
        if(self.n_caja % 5 != 0):
            pilas +=1
        self.grid = ap.Grid(self, (s, s), track_empty=True)
        self.agents = ap.AgentList(self, n, agenteRobot)
        self.cajas = ap.AgentList(self,self.n_caja, agenteCaja)
        self.pilas = ap.AgentList(self,pilas, agentePila)
        self.grid.add_agents(self.pilas,random = False, empty = True, positions = [(i,0) for i in range(pilas)])
        self.grid.add_agents(self.agents, random = True, empty = True)
        self.grid.add_agents(self.cajas, random = True, empty = True)
        
        
        self.agents.setup_parameters(self.p.velocidad, self.p.cajaCarga, self.p.posX, self.p.posZ,s,s)
    
    def step(self):
        for i in self.grid.positions:
            print (i, self.grid.positions[i])
            
        self.agents.detectarCargaCaja()
        self.agents.detectarObstaculos()
        self.agents.actualizarPosicion()
        
        
        #if(stuck):
         #   self.agents.agenteRobot.position - 1 para abajo

    def update(self):
        #self.agents.actualizarVelocidad(self.p.velocidad)
        cajitas = 0
        for pila in self.pilas:
            cajitas += pila.cajas
        if cajitas == self.n_caja:
            self.stop()
    
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
    
