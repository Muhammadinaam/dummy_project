import { Component, OnInit } from '@angular/core';
import { ServerInfo } from '../classes/ServerInfo';

@Component({
  selector: 'app-party-add-edit',
  templateUrl: './party-add-edit.component.html',
  styleUrls: ['./party-add-edit.component.scss']
})
export class PartyAddEditComponent implements OnInit {

  getSchemaAndOptionsUrl = ServerInfo.ServerUrl + "/api/party/get-schema-and-options";
  insertUrl = ServerInfo.ServerUrl + "/api/party/add";
  updateUrl = ServerInfo.ServerUrl + "/api/party/get-schema-and-options";

  constructor() { }

  ngOnInit() {
  }

}
