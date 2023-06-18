import { createSlice } from "@reduxjs/toolkit";

export interface ThemeState {
  theme: string;
}
const initialState: ThemeState = {
  theme: "dark",
};
export const ThemeSlice = createSlice({
  name: "theme",
  initialState,
  reducers: {
    ToggleTheme: (state) => {
      state.theme = state.theme === "dark" ? "light" : "dark";
    },
  },
});

export const { ToggleTheme } = ThemeSlice.actions;
export default ThemeSlice.reducer;
