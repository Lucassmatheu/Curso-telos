function contarFrequencia(str)
{
   const frequencia = {};
    for (const char of str) {
        frequencia[char] = (frequencia[char] || 0) + 1;
    }
    return frequencia;
}
const texto = "javascript";
console.log(contarFrequencia(texto));

