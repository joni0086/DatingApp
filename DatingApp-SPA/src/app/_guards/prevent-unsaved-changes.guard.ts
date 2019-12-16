import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

/* PreventUnsavedChanges (GUARD)
 *
 * The purpose of this guard is to prevent users from clicking on a link while editing their profiles
 * if they have unsaved changes. Normally that would resolve in that the data is lost, however, this
 * guard creates a popup warning letting the user know that changes will be lost if they do that.
 *
 * Note:    This guard does not prevent lost changes if the user "presses X on a web tab", i.e., if
 *          the user closes the page. That is done by the HostListeningDecorator.
 *          See: member-edit.component.ts
 *
 * Author:  JoNi
 * Date:    2019-12-16
 */

@Injectable()
export class PreventUnsavedChanges implements CanDeactivate<MemberEditComponent> {
    canDeactivate(component: MemberEditComponent) {
        /* If the user clicks Ok, they will move on to the page they want to navigate to.
         * If the form is not dirty then we will return true anyway.
         * If the user clicks no on the confirm box, then true will not be returned.
         */
        if (component.editForm.dirty) {
            return confirm('Are you sure you want to continue? Any unsaved changes will be lost');
        }
        return true;
    }
}