import matplotlib.pyplot as plt
import numpy as np
infile1 = open('input.txt', 'r')
infile2 = open('output2.txt', 'r')

values_input = []
values_output = []

#for line2 in infile2:
#    values_output.append(line2.strip('\n'))

linijki = {1,2,3,4,5,6}

for i, row in enumerate(infile1):
    if i in linijki:
        values_input.append(row.strip('\n'))

for i, row in enumerate(infile2):
    if i in linijki:
        values_output.append(row.strip('\n'))

#for line1 in infile1:
#    values_input.append(line1.strip('\n'))

#plt.subplot(1, 2, 1)
plt.plot(values_output, values_input,'o-')
plt.title('Wykres dla 6 przykładów')
plt.gcf().subplots_adjust(left=0.28)
plt.ylabel('Data w postaci binarnej')
plt.xlabel('Data[rok-miesiac-dzien]')

plt.savefig('wykres.png')
