/* Photo (TypeScript Interface)
 *
 * Used in order to specify a photo type.
 * These are used in the user type.
 *
 * Author:  JoNi
 * Date:    2019-12-13
 */
export interface Photo {
    id: number;
    url: string;
    description: string;
    dateAdded: Date;
    isMain: boolean;
}
