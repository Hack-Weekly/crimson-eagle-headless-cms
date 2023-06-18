import { createSlice } from "@reduxjs/toolkit";

export type User = {
  userId: string;
  companyName: string | null;
  token: string;
  refreshToken: string;
};

export interface AuthState {
  token: string | null;
}
const initialState: AuthState = {
  token: null,
};
export const AuthSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    login: (state) => {},
    signup: (state) => {},
    logout: (state) => {},
  },
});

export const {} = AuthSlice.actions;
export default AuthSlice.reducer;
