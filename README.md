# Blazor Cursor Pagination Component

A reusable Blazor pagination component using cursor-based navigation to efficiently load and display cursor paged data from any service. Intended for use in API like OKTA which supports cursor pagination.  Okta Management API - You can find the documentation [here](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/User/#tag/User/operation/listUsers).

## Features

Cursor-based pagination for efficient data retrieval
Flexible RenderFragment support for custom headers and rows
Simple API with callback for page change events
Built-in Prev/Next buttons with disabled state handling

## Why use Cursor Pagination

Cursor-based pagination offers several advantages over traditional offset-based approaches, especially for large or dynamic data sets:

Performance and Scalability: Cursors reference pointers in the data stream (e.g., a unique ID or timestamp), avoiding costly OFFSET scans in SQL queries. This reduces database load and scales efficiently as your data grows.

Consistent Results: When underlying data changes (inserts/deletions), offset-based pagination can skip or duplicate items. Cursor pagination maintains a stable pointer, ensuring users see each item exactly once.

Reduced Latency: Queries using cursors typically run faster because they leverage indexed columns directly, resulting in quicker page loads and a smoother user experience.

Infinite Scroll & Real-Time Feeds: Cursors naturally support “load more” or infinite scroll interfaces. They also handle real-time scenarios (e.g., new posts) more gracefully, as you always fetch the next segment from the last known position.

## Prerequisites

.NET 7 SDK

Blazor WebAssembly or Server project

## Installation

Clone this repository:

git clone https://github.com/yourusername/BlazorCursorPagination.git
cd BlazorCursorPagination

Add the CursorPagination project to your solution and reference it in your main Blazor app.

## Component

| Parameter | Type | Description |
| --------------- | --------------- | --------------- |
| TItem   | type parameter   | The data model type   |
| Items   | IEnumerable<TItem>?   | The collection of items for the current page   |
| CurrentPage   | int   | The current page index (1-based)    |
| PageSize   | int | Number of items per page (optional)   |
| HasMorePages   | bool  | Indicates if there are more pages to fetch   |
| OnPageChanged   | EventCallback<int>  | Callback invoked when user navigates pages   |
| childContentHeader   | RenderFragment   | Custom table header content   |
| childContentRow   | RenderFragment<TItem>  | Custom row template for each item  |

##Contributing

Contributions, issues, and feature requests are welcome! Please open a GitHub issue or submit a pull request.

##License

MIT © Charlie-Porter
