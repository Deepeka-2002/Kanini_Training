import { Component } from '@angular/core';

@Component({
 //selector: 'app-servers',
  selector: '.app-servers',
 // selector:'[app-server]',
  templateUrl: './servers.component.html',
  styleUrls: ['./servers.component.css']
})
export class ServersComponent {
  serverCreateOption : boolean = false;
  serverStatus : string ="Offline";
  serverName : string = " ";
  serverCreated : string = "not yet Created";
  serversList =['SQL', 'ORACLE','MSACCESS',''];
  num : number = 0;
  serverSelected: string = '';

constructor()
{
  setTimeout(() =>{
    this. serverCreateOption = true
  }, 5000);
}
 onServerAdd()
 {
   this.serverStatus = "Online";
   this.serversList.push(this.serverName);
 }

 /*onServerNameType(event : Event)
 {
    return this.serverName = (<HTMLInputElement>event.target).value;
    
 }*/

}
