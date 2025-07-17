#!/bin/bash

# BoomSQL GUI Runner Script
# This script sets up a virtual display and runs BoomSQL with GUI support

echo "🚀 Starting BoomSQL with GUI support..."
echo "========================================"

# Check if Xvfb is available
if ! command -v xvfb-run &> /dev/null; then
    echo "❌ Xvfb not found. Installing..."
    sudo apt update && sudo apt install -y xvfb
fi

# Set up display environment
export DISPLAY=:99
export XVFB_SCREEN_SIZE="1920x1080x24"

# Kill any existing Xvfb processes on display :99
pkill -f "Xvfb :99" 2>/dev/null || true
sleep 1

echo "🖥️  Starting virtual display..."
# Start Xvfb in background
Xvfb :99 -screen 0 $XVFB_SCREEN_SIZE -ac +extension GLX +render -noreset &
XVFB_PID=$!

# Wait for Xvfb to start
sleep 2

# Function to cleanup on exit
cleanup() {
    echo "🧹 Cleaning up..."
    kill $XVFB_PID 2>/dev/null || true
    pkill -f "Xvfb :99" 2>/dev/null || true
    exit 0
}

# Set trap for cleanup
trap cleanup EXIT INT TERM

echo "✅ Virtual display started on :99"
echo "🎯 Launching BoomSQL..."
echo ""

# Run BoomSQL
python3 boomsql.py

# Cleanup will be handled by trap
