import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
let ContactsUpdateComponent = class ContactsUpdateComponent {
    constructor(formBuilder, contactService, toastr) {
        this.formBuilder = formBuilder;
        this.contactService = contactService;
        this.toastr = toastr;
        this.form = this.formBuilder.group({
            firstName: [null, [Validators.required]],
            lastName: [null, [Validators.required]],
            company: [null, [Validators.required]],
            email: [null, [Validators.required]],
            phoneNumber: [null, [Validators.required]]
        });
    }
    ngOnInit() {
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
    createContact() {
        if (this.idContact == null) {
            this.add();
        }
        else {
            this.edit();
        }
    }
    edit() {
        var _a, _b, _c, _d, _e;
        const contact = {
            id: this.contact.id,
            firstName: (_a = this.form.get('firstName')) === null || _a === void 0 ? void 0 : _a.value,
            lastName: (_b = this.form.get('lastName')) === null || _b === void 0 ? void 0 : _b.value,
            company: (_c = this.form.get('company')) === null || _c === void 0 ? void 0 : _c.value,
            email: (_d = this.form.get('email')) === null || _d === void 0 ? void 0 : _d.value,
            phoneNumber: (_e = this.form.get('phoneNumber')) === null || _e === void 0 ? void 0 : _e.value,
        };
        this.contactService.updateContact(this.idContact, contact).subscribe(data => {
            this.toastr.info("Edit Contact Success", "Contact was Update");
            this.contactService.getContacts();
            this.form.reset();
            this.idContact = null;
        });
    }
    add() {
        var _a, _b, _c, _d, _e;
        const contact = {
            firstName: (_a = this.form.get('firstName')) === null || _a === void 0 ? void 0 : _a.value,
            lastName: (_b = this.form.get('lastName')) === null || _b === void 0 ? void 0 : _b.value,
            company: (_c = this.form.get('company')) === null || _c === void 0 ? void 0 : _c.value,
            email: (_d = this.form.get('email')) === null || _d === void 0 ? void 0 : _d.value,
            phoneNumber: (_e = this.form.get('phoneNumber')) === null || _e === void 0 ? void 0 : _e.value,
        };
        this.contactService.saveContact(contact).subscribe(data => {
            this.toastr.success("Create Contact Success", "Contact Registed");
            this.contactService.getContacts();
            this.form.reset();
        });
    }
};
ContactsUpdateComponent = __decorate([
    Component({
        selector: 'app-contacts-update',
        templateUrl: './contacts-update.component.html',
        styleUrls: ['./contacts-update.component.css']
    })
], ContactsUpdateComponent);
export { ContactsUpdateComponent };
//# sourceMappingURL=contacts-update.component.js.map