"use client";

import { Media, columns } from "./columns";
import { DataTable } from "./data-table";

async function getData(): Promise<Media[]> {
  // Fetch data from API here.
  return [
    {
      ProjectId: "728ed52f",
      Title: "frog.jpg",
      Category: "Image",
      Description: "I saw this frog today",
      UploadedBy: "Dave",
      UploadedAt: "25/3/23",
    },
  ];
}

export default async function DemoPage() {
  const data = await getData();

  return (
    <div className="container mx-auto py-10">
      <DataTable columns={columns} data={data} />
    </div>
  );
}
