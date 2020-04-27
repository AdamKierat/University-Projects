import glob
import matplotlib.pyplot as plt
import os.path



strona = open("strona.html", 'w', encoding="utf-8")

sciezka1 = "input.txt"
sciezka2 = "output.txt"

plikiinput = glob.glob(sciezka1)
plikioutput = glob.glob(sciezka2)

input = []
output = []

for name in plikiinput:
    with open(name) as f:
        word = f.readlines()
        input += word
        f.close()

for name in plikioutput:
    with open(name) as f:
        word = f.readlines()
        output += word
        f.close()

strona.write('<!DOCTYPE HTML>\n'
           '<html lang="pl">\n<head>'
           '<title>Adam Kierat Projekt</title>\n'
           '<link rel="stylesheet" href="style.css" type="text/css" /> \n'
           '</head> \n'
           '<body> \n'
           '<div id="container"> \n'
           '<div id="header">WI_DATY- Projekt Jezyki Skryptowe</div> </div> \n'
           '<div id="content"> \n'
           '<div id="tab">\n'
           '<table>\n'
           '<tr>\n'
           '<th>Data w systemie binarnym</th>\n'
           '<th>Data w systemie dziesiątkowym</th>\n'
           '</tr>\n')
i = 0

while (i<len(input)):
    strona.write('                 <tr>\n                     '
               '                       <td>')
    strona.write(input[i].replace('\n', ''))
    strona.write('</td>\n                     <td>')
    strona.write(output[i].replace('\n', ''))
    strona.write('</td> \n                 </tr>\n')
    i = i+1

strona.write(
           '                </table>\n'
           '            </div>\n'
           '        <center><img src="wykres.png"></center>   </div> \n'
           '           <div id="footer"> \n'
           '                 Adam Kierat WI_DATY- Projekt Jezyki Skryptowe, 2019  \n'
           '           </div> \n'
           '    </div> \n'
           '</body> \n')

strona.close()
