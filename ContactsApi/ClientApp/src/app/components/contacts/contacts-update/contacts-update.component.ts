import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup,Validators,FormBuilder } from '@angular/forms';
import { ContactsService } from '../../../services/contacts.service';
import { Contact } from '../../../models/contact';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-contacts-update',
  templateUrl: './contacts-update.component.html',
  styleUrls: ['./contacts-update.component.css']
})
export class ContactsUpdateComponent implements OnInit, OnDestroy{
  subscription: Subscription;
  form: FormGroup;
  contact: Contact;
  idContact: undefined;

  constructor(private formBuilder: FormBuilder,
    private contactService: ContactsService,
    private toastr: ToastrService)
  {
    
    this.form = this.formBuilder.group({
     
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      company: [null, [Validators.required]],
      email: [null, [Validators.required]],
      phoneNumber: [null, [Validators.required]]
    });

   }

  ngOnInit(): void {
    this.subscription = this.contactService.getContact().subscribe(data => {
      console.log(data);
      this.contact = data;
      this.form.patchValue({
        firstName: this.contact.firstName,
        lastName: this.contact.lastName,
        company: this.contact.company,
        email: this.contact.email,
        phoneNumber: this.contact.phoneNumber
      });
      this.idContact = this.contact.id;
    });
  }
    
  

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  createContact()
  {
    if (this.idContact == null)
    {
      this.add()
    }
    else
    {
      this.edit()
    }
    
  }

  edit() {
    const contact: Contact = {
      id: this.contact.id,
      firstName: this.form.get('firstName')?.value,
      lastName: this.form.get('lastName')?.value,
      company: this.form.get('company')?.value,
      email: this.form.get('email')?.value,
      phoneNumber: this.form.get('phoneNumber')?.value,
    };  
    this.contactService.updateContact(this.idContact,contact).subscribe(data => {
      this.toastr.info("Edit Contact Success", "Contact was Update");
      this.contactService.getContacts();
      this.form.reset();
      this.idContact = null;
    });
  }

  add() {
    const contact: Contact = {
      firstName: this.form.get('firstName')?.value,
      lastName: this.form.get('lastName')?.value,
      company: this.form.get('company')?.value,
      email: this.form.get('email')?.value,
      phoneNumber: this.form.get('phoneNumber')?.value,
    };
    this.contactService.saveContact(contact).subscribe(data => {
      this.toastr.success("Create Contact Success", "Contact Registed");
      this.contactService.getContacts();
      this.form.reset();
    });
  }

}
