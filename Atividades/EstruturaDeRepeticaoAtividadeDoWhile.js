function executarExercicio()
{
   var numero = prompt("Digite um numero ")
   var controle = 1;
   var resultado =0;

   do 
   {
    resultado = resultado + controle;
    controle++;
   }while(controle <= numero);
}