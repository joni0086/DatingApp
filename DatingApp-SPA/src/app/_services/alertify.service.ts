import { Injectable } from '@angular/core';
import * as alertify from 'alertifyjs';

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }

  // Confirm message
  confirm(message: string, okCallback: () => any) {
    alertify.confirm(message, (e: any) => {
      if (e) {
        okCallback();
      } else {}
    });
  }

  // Success message
  success(message: string) {
    alertify.success(message);
  }

  // Error message
  error(message: string) {
    alertify.error(message);
  }

  // Warning message
  warning(message: string) {
    alertify.warning(message);
  }

  // Normal message
  message(message: string) {
    alertify.message(message);
  }
}
