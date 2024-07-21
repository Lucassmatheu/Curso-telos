class Fila
{
    constructor()    
    {
        this.items = [];
    }
   enqueue(elemento) 
   {
        this.items.push(elemento);
    }
    dequeue()
    {
        if(this.isEmpty()) return "Underflow";
        return this.items.shift();
    }
    isEmpty()
    {
        return this.items.length === 0;
    }
    front()
    {
        if(this.isEmpty()) return "No elements in Queue";
        return this.items[0];
    }
}

const fila = new Fila();
fila.enqueue(10);
fila.enqueue(20);
fila.enqueue(30);
console.log(fila.dequeue()); // 10
console.log(fila.front()); // 20
