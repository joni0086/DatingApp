import { Photo } from './photo';

/* User (TypeScript Interface)
 *
 * Used in order to specify a type for the user.
 *
 * Author:  JoNi
 * Date:    2019-12-13
 */
export interface User {
    id: number;
    username: string;
    knownAs: string;
    age: number;
    gender: string;
    created: Date;
    lastActive: any;
    photoUrl: string;
    city: string;
    country: string;
    interests?: string;
    introduction?: string;
    lookingFor?: string;
    photos?: Photo[];
}
