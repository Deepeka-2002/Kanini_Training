import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Button} from 'bootstrap';
import { FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { ServerComponent } from './server/server.component';
import { ServersComponent } from './servers/servers.component';
import { PipesComponent } from './pipes/pipes.component';
import { NamefilterPipe } from './namefilter.pipe';
import { WordcountPipe } from './wordcount.pipe';

@NgModule({
  declarations: [
    AppComponent,
    ServerComponent,
    ServersComponent,
    PipesComponent,
    NamefilterPipe,
    WordcountPipe
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
