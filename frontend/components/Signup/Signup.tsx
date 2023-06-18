import Link from "next/link";
import React from "react";
import SignupForm from "./SignupForm";

type SignupProps = {};

const Signup: React.FC<SignupProps> = () => {
  return (
    <div
      className="
flex gap-4 flex-col
w-full  border-2 rounded-md px-10 py-12 drop-shadow-xl"
    >
      <h2 className="text-3xl">Sign up</h2>
      <SignupForm />
      <div className=" w-full flex align-middle justify-center ">
        Already have an account?{" "}
        <Link href={"/login"} className=" cursor-pointer">
          Log in
        </Link>
      </div>
    </div>
  );
};
export default Signup;
