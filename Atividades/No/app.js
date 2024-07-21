function buscaBinaria(arr, target)
{
    let esquerda = 0;
    let direita = arr.length - 1;

    while(esquerda <= direita)
    {
        const meio = Math.floor((esquerda = direita) / 2 );
        if(arr[meio] === target)
        {
            return meio;
        }else if(arr[meio] < target)
        {
            esquerda = meio + 1;
        } else
        {
            direita = meio - 1;
        }
    }
    return - 1;
}
const array = [1, 2, 3, 4, 5, 6, 7, 8, 9];
console.log(buscaBinaria(array, 4)); // 3
console.log(buscaBinaria(array, 10)); // -1