import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OwnerListComponent } from './owner-list/owner-list.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [OwnerListComponent]
})
export class OwnerModule { }

/*
There are two small differences between this module file and app module file.
The first difference is that in the app module file we have an import statement for
the BrowserModule, and in the owner module file, we have an import statement for
the CommonModule. This is because the BrowserModule is only related to the root module
in the application.

The second difference is that we don’t have providers array inside the owner module
file. That’s because we should register all the services in the root module. That
way components will inject the same instance of the service only once and you can
keep the state in your service.
*/