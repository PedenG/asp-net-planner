import { Component, OnInit } from '@angular/core';
import moment = require('moment');

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {

  private listDays = [];
  private numWeek = moment().isoWeek();
  private curentDate;
  constructor() {
    
   }

  ngOnInit() {
    this.getListOfDayByWeekNumber();
  }

  private getListOfDayByWeekNumber(){
    this.curentDate = moment().day("Monday").week(this.numWeek);
    this.listDays = [];
    for(let  i = 1; i < 8; i++){
        this.listDays.push(moment(this.curentDate).day(i).format('DD/MM'));
    }
    this.curentDate = moment(this.curentDate).format('YYYY-MM-DD');
  }
}
