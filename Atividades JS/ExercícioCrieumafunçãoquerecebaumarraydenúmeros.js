function doubleArray(arr)
{
    let double =[] ;

    for(let i = 0; i< arr.length; i++)
    {
        double.push(arr[i]* 2);
    }
    return double;
} 
let numbrs = [1,2,3,4,5,];

console.log(doubleArray(numbers));