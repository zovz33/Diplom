import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'cutText'
})
export class CutTextPipe implements PipeTransform {

  transform(value: string, MaxLength=100) : string {
    if(value.length > MaxLength) return value.substring(0,MaxLength)+"...";
    else
    return value;
  }

}
