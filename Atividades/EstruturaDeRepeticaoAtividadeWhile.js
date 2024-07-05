function executarExercicio()
{
   var numero = prompt("Digite um numero ")
   var controle = 1;
   var resultado =0;

   while(controle <= numero)
   {
    resultado = resultado + controle;
    controle++;

   }

   console.log(resultado)
}