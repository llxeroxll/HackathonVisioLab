
# coding: utf-8

# In[38]:

import numpy as np
import sqlite3
import random
import time


def strTimeProp(start, end, format, prop):

    stime = time.mktime(time.strptime(start, format))
    etime = time.mktime(time.strptime(end, format))

    ptime = stime + prop * (etime - stime)

    return time.strftime(format, time.localtime(ptime))


def randomDate(start, end, prop):
    return strTimeProp(start, end, '%Y-%m-%d %I:%M', prop)


# In[39]:


# conectando...
conn = sqlite3.connect('D:\\Arquivos\\Dropbox\\HackatonConductor\\HackathonVisioLab\\Resource\\db.sqlite3')
file = "C:\\Users\\Iron\\Desktop\\TempHack\\maguim.csv"
my_data = np.genfromtxt(file, dtype=str,delimiter=';')
# definindo um cursor
cursor = conn.cursor()
cursor1 = conn.cursor()
cursor2 = conn.cursor()


# In[41]:

"""
    for attr in my_data:
    cpf =  "{}.{}.{}-{}".format(random.randint(000,999),random.randint(000,999),random.randint(000,999),random.randint(00,99));
    nome = attr[0]
    senha = "123"
    cursor.execute("INSERT INTO Cliente (CPF, Nome, Senha) VALUES(?, ?, ?)",(cpf,nome,senha))

    # gravando no bd
    conn.commit()
"""

cursor.execute("SELECT * FROM Cliente;")
cursor1.execute("SELECT * FROM Produto;")



clientList = cursor.fetchall();
produtList = cursor1.fetchall();

for i in range(500):
    cliente = clientList[random.randint(0,len(clientList)-1)]
    produto = produtList[random.randint(0,len(produtList)-1)]
    randDate = randomDate("2008-1-1 1:30", "2017-2-18 4:50", random.random());
    print (cliente[0],produto[0], randDate)
    cursor2.execute("INSERT INTO Compra(ID_cliente,ID_produto,Horario) VALUES(?,?,?)",(cliente[0],produto[0],str(randDate)))
conn.commit();
# desconectando...
#conn.close()






# In[42]:

conn.close()


# In[ ]:



