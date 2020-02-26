import {
  Directive,
  ElementRef,
  Injectable,
  Input,
  SimpleChanges,
  OnChanges
} from '@angular/core';

@Directive({
  selector: '[busy]'
})
@Injectable()
export class BusyDirective implements OnChanges {
  @Input('busy') loading: boolean;

  constructor(private _element: ElementRef) {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['loading'].currentValue) {
      abp.ui.setBusy(this._element.nativeElement);
    } else {
      abp.ui.clearBusy(this._element.nativeElement);
    }
  }
}
