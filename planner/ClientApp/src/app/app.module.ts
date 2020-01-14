import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CalendarComponent } from './calendar/calendar.component';
import { ListCalendarComponent } from './list-calendar/list-calendar.component';
import { AddCalendarComponent } from './add-calendar/add-calendar.component';
import { UserComponent } from './user/user.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CalendarComponent,
    ListCalendarComponent,
    AddCalendarComponent,
    UserComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: CalendarComponent, pathMatch: 'full' },
      { path: 'list', component: ListCalendarComponent },
      { path: 'add', component: AddCalendarComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
