# auth_signup 

- **Sign up** - registration (name: `auth_signup`):
    - `auth_signup_id: integer` - registration ID,
    - `signup_guid: varchar` - registration GUID,
    - `user_guid: varchar` - GUID of the created user,
    - `verification_code: varchar` - registration confirmation code,
    - `vc_sending_dt: timestamp` - time of sending the confirmation code,
    - `tries_number: integer` - number of attempts to enter the registration code,
    - `signup_begin_dt: timestamp` - start of registration,
    - `signup_end_dt: timestamp` - end of registration,
    - `is_deprecated: boolean` - "deprecated" sign,
    - `is_overriden: boolean` - sign "overwritten",
    - `auth_closing_code_id: integer` -  closing code.

Corresponds to the [AuthSignUp](../models/AuthSignUp.md).
