import { Component, OnInit } from '@angular/core';
import { HttpClientService } from 'src/app/http-client.service';

@Component({
  selector: 'app-edit-order',
  templateUrl: './edit-order.component.html',
  styleUrls: ['./edit-order.component.scss']
})
export class EditOrderComponent implements OnInit {

  constructor(private httpClientService: HttpClientService) { }

  ngOnInit() {
  }

}
