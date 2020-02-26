import {
  Directive,
  ElementRef,
  Injectable,
  Input,
  SimpleChanges,
  OnChanges
} from '@angular/core';

@Directive({
  selector: '[block]'
})
@Injectable()
export class BlockDirective implements OnChanges {
  @Input('block') loading: boolean;

  constructor(private _element: ElementRef) {}

  ngOnChanges(changes: SimpleChanges): void {
    $.blockUI.defaults.overlayCSS.cursor = 'not-allowed';
    if (changes['loading'].currentValue) {
      abp.ui.block(this._element.nativeElement);
    } else {
      abp.ui.unblock(this._element.nativeElement);
    }
  }
}
