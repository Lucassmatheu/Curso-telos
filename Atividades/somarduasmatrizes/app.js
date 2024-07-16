function somaMatrizes(matriz1, matriz2) {
    let resultado = [];
    for (let i = 0; i < matriz1.length; i++) {
        let linha = [];
        for (let j = 0; j < matriz1[i].length; j++) {
            linha.push(matriz1[i][j] + matriz2[i][j]);
        }
        resultado.push(linha);
    }
    return resultado;
}

const matrizA = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
];

const matrizB = [
    [9, 8, 7],
    [6, 5, 4],
    [3, 2, 1]
];

console.log(somaMatrizes(matrizA, matrizB));
// [
//     [10, 10, 10],
//     [10, 10, 10],
//     [10, 10, 10]
// ]
