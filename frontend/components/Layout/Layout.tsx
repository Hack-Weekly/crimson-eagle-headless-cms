import { themeContext } from "@/context/themeContext";
import { Inter } from "next/font/google";
import React, { useContext } from "react";
import Navbar from "../Navbar/Navbar";

type LayoutProps = { children: React.ReactNode };
const inter = Inter({ subsets: ["latin"] });

const Layout: React.FC<LayoutProps> = ({ children }) => {
  const context = useContext(themeContext);
  return (
    <html lang="eng" className={`${context?.theme}`}>
      <body className={` ${inter.className}`}>
        <main>
          <Navbar />
          {children}
        </main>
      </body>
    </html>
  );
};
export default Layout;
