import os
import matplotlib.pyplot as plt
import numpy as np

files = os.listdir("Results")
distances = []
gaps = []

for file_path in files:
    file = open("Results/" + file_path, 'r')
    lines = [line.replace(',', '.') for line in file.readlines()]
    distances.append(float(lines[6].split("\t")[1][:-1]))
    gaps.append(float(lines[8].split("\t")[1][:-1]))


if len(distances) > 1:
    x = np.arange(len(distances))

    plt.subplot(1, 2, 1)
    plt.plot(x, distances)
    plt.title('Variance of the best distance')

    # cost function for sgd
    plt.subplot(1, 2, 2)
    plt.plot(x, gaps)
    plt.title('Variance of the distance GAP')

    plt.show()