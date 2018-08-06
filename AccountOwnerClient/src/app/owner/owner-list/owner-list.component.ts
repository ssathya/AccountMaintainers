import { Component, OnInit } from '@angular/core';

import { RepositoryService } from './../../shared/services/repository.service';
import { Owner } from './../../_interfaces/owner.model';

@Component({
  selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css']
})
export class OwnerListComponent implements OnInit {
  public owners: Owner[];
  public getAllOwners() {
    const apiAddress = 'api/owner';
    this.repository.getData(apiAddress)
      .subscribe(r => {
        this.owners = r as Owner[];
      });
  }
  constructor(private repository: RepositoryService) { }

  ngOnInit() {
    this.getAllOwners();
  }

}
