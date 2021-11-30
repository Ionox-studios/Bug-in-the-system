# -*- coding: utf-8 -*-
"""
Created on Fri Nov 27 14:59:38 2020

@author: Conor
"""
import os
directory = r'C:\Users\Conor\Downloads\Dialogues (1)'
file_list =os.listdir(directory)
for file_name in file_list:
    fname = os.path.join(directory,file_name)
    f = open(fname,'r')
    zz = f.readlines()
    out =[]
    for line in zz:
        if len(line)>1:
            line=line[:-2]+r'"));'
            line = line+'\n'
            line =r'dialogTexts.Add(new DialogData('+line
            line =line.replace(r'",',r'/wait:1//close/ ",')
        out.append(line)
    outname = fname+'out.txt'
    f2 = open(outname,'w')
    f2.writelines(out)
    f.close()
    f2.close()