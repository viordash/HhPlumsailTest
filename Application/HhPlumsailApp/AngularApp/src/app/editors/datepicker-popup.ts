import { Component, Input, Output, EventEmitter } from '@angular/core';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'ngbd-datepicker-popup',
    templateUrl: './datepicker-popup.html'
})
export class NgbdDatepickerPopup {
    ngbDate: NgbDate;
    date: Date; //for store time part & tz of date

    @Input()
    set selectedDate(date: any) {
        this.date = new Date(date);
        this.ngbDate = new NgbDate(this.date.getFullYear(), this.date.getMonth() + 1, this.date.getDate());;
    }

    @Output() selectedDateChange = new EventEmitter<Date>();
    onSelectedDateChange(model: any) {
        if (!!!model || !!!model.valid) {
            return;
        }
        this.ngbDate = model.value;
        this.date.setFullYear(model.value.year);
        this.date.setMonth(model.value.month - 1);
        this.date.setDate(model.value.day);
        this.selectedDateChange.emit(this.date);
    }
}
