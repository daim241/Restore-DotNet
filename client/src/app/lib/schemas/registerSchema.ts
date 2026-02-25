import z from "zod";

const passwordValidation = new RegExp(
    /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$/
)

export const registerSchema = z.object({
    email: z.string().email(),
    password: z.string().regex(passwordValidation, {
        message: 'Password must contain This regex ensures at least one uppercase letter, one lowercase letter, one digit, one special character, and a minimum length of 8 characters.'
    })
});

export type RegisterSchema = z.infer<typeof registerSchema>;