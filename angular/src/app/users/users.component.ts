import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})
export class UsersComponent extends AppComponentBase {
  constructor(injector: Injector) {
    super(injector);
  }
}
