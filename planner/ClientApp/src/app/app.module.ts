import { AddCalandarService } from './service/add-calandar.service';
import { LoginService } from './service/login.service';
import { UserService } from './service/user.service';
import { HttpModule } from '@angular/http';
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
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CalendarComponent,
    ListCalendarComponent,
    AddCalendarComponent,
    UserComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'list', component: ListCalendarComponent },
      { path: 'add', component: AddCalendarComponent },
      { path: 'user', component: UserComponent },
      { path: 'Calendar', component:CalendarComponent },
    ])
  ],
  providers: [UserService, LoginService,AddCalandarService],
  bootstrap: [AppComponent]
})
export class AppModule { }
