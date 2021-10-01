import { __decorate } from "tslib";
import { Component } from '@angular/core';
let ContactsListComponent = class ContactsListComponent {
    constructor(contactService, toastr) {
        this.contactService = contactService;
        this.toastr = toastr;
    }
    ngOnInit() {
        this.contactService.getContacts();
    }
    onChangePage(pageOfItems) {
        this.pageOfItems = pageOfItems;
    }
    deleteContact(id) {
        if (confirm("Are you sure want to delete the record?")) {
            this.contactService.deleteContact(id).subscribe(data => {
                this.toastr.warning("The record was deleted", "Delete Record");
                this.contactService.getContacts();
            });
        }
    }
    editContact(contact) {
        this.contactService.update(contact);
    }
};
ContactsListComponent = __decorate([
    Component({
        selector: 'app-contacts-list',
        templateUrl: './contacts-list.component.html',
        styleUrls: ['./contacts-list.component.css']
    })
], ContactsListComponent);
export { ContactsListComponent };
//# sourceMappingURL=contacts-list.component.js.map