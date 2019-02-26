import csv

with open('export.csv', newline='' ,encoding='utf8') as csvfile:
  rows = csv.reader(csvfile)
  for row in rows:
    print(row)

a = input()