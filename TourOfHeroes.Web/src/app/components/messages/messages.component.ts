import { Component, OnInit } from '@angular/core';
import { MessageService } from '../../services/message.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {

  /* The messageService property must be public because it's
   binded in the template */
  constructor(public messageService: MessageService) { }

  ngOnInit(): void {
  }

}
