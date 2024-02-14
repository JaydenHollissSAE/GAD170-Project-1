import csv

f = open("namesDatabase.py", "w")
namesList = ["Nobody"]

with open('baby-names.csv') as csv_file:
    csv_reader = csv.reader(csv_file, delimiter=',')
    line_count = 0
    for row in csv_reader:
        if line_count == 0:
            line_count += 1
        else:
            namesList.append({row[1]})
            line_count += 1

f.write("namesList = "+(str(namesList).replace('{','')).replace('}',''))
f.close()
print("Dumping Done")