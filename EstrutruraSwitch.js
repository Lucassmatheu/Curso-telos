var distancia = prompt("Indique a distancia");
var tipoDeTranpost = prompt("Tipo de tranporte");

switch(tipoDeTranpost){
 case "Terretre":
    console.log("Entrou terrestre");
 break
 case "Aereo":
    console.log("Entrou Aero");
 break
 case "Maritimo":
    console.log("Entrou Maritimo")  
break
default:
    console.log("tipo de tranposte invalido")
}