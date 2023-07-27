import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'wordcount'
})
export class WordcountPipe implements PipeTransform {

  transform(customText: any, args?: any ): any {
    return customText.trim().split(/\s+/).length;
  }

}
