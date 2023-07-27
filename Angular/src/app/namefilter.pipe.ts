import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'namefilter'
})
export class NamefilterPipe implements PipeTransform {

  transform(array:string[] , inp : string):any
  {
    let temp:string[] = [];
   // console.log(array, inp);
    temp = array.filter(a => a.startsWith(inp));
    console.log(temp);
    return temp;
  }

}
