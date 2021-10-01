import { Component, OnInit } from '@angular/core';
import { ContactsService } from '../../../services/contacts.service';
import { Contact } from '../../../models/contact';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contacts-list.component.html',
  styleUrls: ['./contacts-list.component.css']
})
export class ContactsListComponent implements OnInit {
   
    items : Contact[];
    pageOfItems: Array<Contact>;
    
  
  

  constructor(public contactService: ContactsService,
              public toastr:ToastrService) { }

  ngOnInit() : void {  
    this.contactService.getContacts();   
  }

  onChangePage(pageOfItems: Array<Contact>) {       
        this.pageOfItems = pageOfItems;
  }

  deleteContact(id: undefined) {
    if (confirm("Are you sure want to delete the record?")) {
      this.contactService.deleteContact(id).subscribe(data => {
        this.toastr.warning("The record was deleted","Delete Record");
        this.contactService.getContacts();
      })
    }
  }

  editContact(contact:any) {
    this.contactService.update(contact);
  }

}
