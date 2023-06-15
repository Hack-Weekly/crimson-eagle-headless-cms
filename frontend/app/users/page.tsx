"use client"

import { Users, columns } from "./columns"
import { DataTable } from "./data-table"


async function getData(): Promise<Users[]> {
  // Fetch data from API here.
  return [
    {
      UserId: "666",
      Name: "Diablo",
      Level: "Hell",
    },
    // ...
  ]
}

export default async function DemoPage() {
  const data = await getData()

  return (
    <div className="container mx-auto py-10">
      <DataTable columns={columns} data={data} />
    </div>
  )
}
