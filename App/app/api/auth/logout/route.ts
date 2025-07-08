import { NextRequest, NextResponse } from "next/server";

const API_BASE_URL =
  process.env.API_BASE_URL || "https://your-api-gateway-url.com";

export async function POST(request: NextRequest) {
  try {
    const { refreshToken } = await request.json();
    const authorization = request.headers.get("authorization");

    const response = await fetch(`${API_BASE_URL}/auth/logout`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        ...(authorization && { Authorization: authorization }),
      },
      body: JSON.stringify({ refreshToken }),
    });

    console.log("Logout API response:", response);
    if (!response.ok) {
      const data = await response.json();
      return NextResponse.json(
        { error: data.message || "Logout failed" },
        { status: response.status },
      );
    }

    return NextResponse.json({ success: true });
  } catch (error) {
    console.error("Logout API error:", error);
    return NextResponse.json(
      { error: "Internal server error" },
      { status: 500 },
    );
  }
}
