import * as React from "react";
import { LineChart } from "@mui/x-charts/LineChart";

export default function BasicLineChart() {
  return (
    <LineChart
      xAxis={[{ data: [1, 2, 3, 5, 8, 10] }]}
      series={[
        {
          //label: "label",
          data: [2, 5.5, 2, 8.5, 1.5, 5],
          area: true,
          //color: "#006dff26",
          //color: "rgba(0, 109, 255, 0.15)",
        },
      ]}
      width={500}
      height={300}
    >
      <defs>
        <linearGradient id="stripe" x1="0%" y1="0%" x2="0%" y2="100%">
          <stop offset="0%" stopColor="#0000ff" />
          <stop offset="100%" stopColor="#0000ff" />
        </linearGradient>
        <linearGradient id="stripeContrast" x1="0%" y1="0%" x2="0%" y2="100%">
          <stop offset="0%" stopColor="#ffffff" />
          <stop offset="100%" stopColor="#ffffff" />
        </linearGradient>
        <pattern id="stripes" width="4" height="1" patternUnits="userSpaceOnUse">
          <rect width="2" height="1" fill="url(#stripe)" />
          <rect x="2" width="2" height="1" fill="url(#stripeContrast)" />
        </pattern>
      </defs>
      <style>
        {`
           .MuiAreaElement-root {
             fill: url(#stripes);
           }
        `}
      </style>
    </LineChart>
  );
}

/*
    <LineChart>
      ...
      <defs>
        <linearGradient id="stripe" x1="0%" y1="0%" x2="0%" y2="100%">
          <stop offset="0%" stopColor="#0000ff" />
          <stop offset="100%" stopColor="#0000ff" />
        </linearGradient>
        <linearGradient id="stripeContrast" x1="0%" y1="0%" x2="0%" y2="100%">
          <stop offset="0%" stopColor="#ffffff" />
          <stop offset="100%" stopColor="#ffffff" />
        </linearGradient>
        <pattern id="stripes" width="4" height="1" patternUnits="userSpaceOnUse">
          <rect width="2" height="1" fill="url(#stripe)" />
          <rect x="2" width="2" height="1" fill="url(#stripeContrast)" />
        </pattern>
      </defs>
      <style>
        {`
           .MuiAreaElement-root {
             fill: url(#stripes);
           }
        `}
      </style>
    </LineChart>
*/

/*
    <LineChart>
      ...
      <defs>
        <linearGradient id="stripe" x1="0%" y1="0%" x2="0%" y2="100%">
          <stop offset="0%" stopColor="#0000ff" />
          <stop offset="100%" stopColor="#0000ff" />
        </linearGradient>
        <linearGradient id="stripeContrast" x1="0%" y1="0%" x2="0%" y2="100%">
          <stop offset="0%" stopColor="#ffffff" />
          <stop offset="100%" stopColor="#ffffff" />
        </linearGradient>
        <pattern id="stripes" width="10" height="1" patternUnits="userSpaceOnUse">
          <rect width="5" height="1" fill="url(#stripe)" />
          <rect x="5" width="5" height="1" fill="url(#stripeContrast)" />
        </pattern>
      </defs>
      <style>
        {`
           .MuiAreaElement-root {
             fill: url(#stripes);
           }
        `}
      </style>
    </LineChart>
*/

/*
    <LineChart>
      ...
      <defs>
        <linearGradient id="myGradient" x1="0%" y1="0%" x2="100%" y2="0%">
          <stop offset="0%" stopColor="#ff0000" />
          <stop offset="20%" stopColor="#ff0000" />
          <stop offset="20%" stopColor="#ffffff" />
          <stop offset="40%" stopColor="#ffffff" />
          <stop offset="40%" stopColor="#ff0000" />
          <stop offset="60%" stopColor="#ff0000" />
          <stop offset="60%" stopColor="#ffffff" />
          <stop offset="80%" stopColor="#ffffff" />
          <stop offset="80%" stopColor="#ff0000" />
          <stop offset="100%" stopColor="#ff0000" />
        </linearGradient>
      </defs>
      <style>
        {`
          .MuiAreaElement-root {
            fill: url(#myGradient);
          }
        `}
      </style>
    </LineChart>
*/

/*
<LineChart
    ...
    sx={{
        "& .MuiAreaElement-root": {
            fill: "url(#myGradient)", // Reference your gradient
        },
    }}
    ...
>
*/

/*
    <LineChart
    >
      <defs>
        ...
      </defs>
      <style>
        {`
           .MuiAreaElement-root {
             fill: url(#myGradient);
           }
        `}
      </style>
    </LineChart>
*/
