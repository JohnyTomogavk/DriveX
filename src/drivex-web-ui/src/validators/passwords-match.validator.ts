import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Observable, of } from 'rxjs';

export function passwordsMatch(passwordControlName: string, confirmedPasswordControlName: string): ValidatorFn {
  return (formGroup: AbstractControl): Observable<ValidationErrors | null> => {
    const passwordControl = formGroup.get(passwordControlName);
    const confirmedPasswordControl = formGroup.get(confirmedPasswordControlName);

    let errorsObject = null;

    if (passwordControl?.value !== confirmedPasswordControl?.value) {
      errorsObject = {
        "PASSWORDS_MISMATCH": true
      }
    }

    confirmedPasswordControl?.setErrors(errorsObject);

    return of(errorsObject);
  };
}
