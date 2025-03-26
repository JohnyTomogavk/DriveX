import { Pipe, PipeTransform } from '@angular/core';
import { ValidationErrors } from '@angular/forms';

@Pipe({
  name: 'formError',
  standalone: true,
})
export class FormErrorPipe implements PipeTransform {
  transform(
    errors: ValidationErrors | null | undefined,
    errorPrefix = 'VALIDATION'
  ): string {
    if (!errors) {
      return '';
    }

    const keys = Object.keys(errors);
    if (keys.length === 0) {
      return '';
    }

    return `${errorPrefix}.${keys[0].toUpperCase()}`;
  }
}
