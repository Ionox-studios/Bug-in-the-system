# -*- coding: utf-8 -*-
"""
Created on Fri Nov 27 14:59:38 2020

@author: Conor
"""
import os
directory = r'C:\Users\Conor\Downloads\New Converted Voice Lines\alltxt'
file_list =os.listdir(directory)
for file_name in file_list:
    if 'out.txt' in file_name:
        continue
    fname = os.path.join(directory,file_name)
    f = open(fname,'r')
    zz = f.readlines()
    out =[]
    for ln,line in enumerate(zz):
        if len(line)>2:
            parsed = line.split(',')
            if ln !=(len(zz)-1):
                sound_open = r'"/sound:'+parsed[-1][2:-2]+r'/'
            else:
                sound_open = r'"/sound:'+parsed[-1][2:-1]+r'/'
            line=line[:-1*len(parsed[-1])-2]+r'"));'
            line = line+'\n'
            line = sound_open+line[1:]
            line =r'dialogTexts.Add(new DialogData('+line
            
            line =line.replace(r'",',r'/wait:0.25/",')
        
        out.append(line)
    outname = fname+'out.txt'
    f2 = open(outname,'w')
    f2.writelines(out)
    f.close()
    f2.close()